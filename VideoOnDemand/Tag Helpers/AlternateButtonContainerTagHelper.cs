using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace VideoOnDemand.Tag_Helpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("alternate-button-container")]
    public class AlternateButtonContainerTagHelper : TagHelper
    {
        #region Properties
        private Dictionary<string, string> ButtonGlyphs = new Dictionary<string, string> { { "edit", "pencil" }, { "create", "th-list" }, { "delete", "remove" }, { "details", "info-sign" }, { "index", "list-alt" } };
        public string Controller { get; set; }
        #endregion

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (output == null) throw new ArgumentNullException(nameof(output));

            base.Process(context, output);

            output.TagName = "span";    // Replaces <button-container> with <span> tag
            output.Content.SetHtmlContent("<span style='min-width:100px; display:inline-block;'>");

            var actions = context.AllAttributes.Where(c => c.Name.StartsWith("action-"));
            var buttonTypes = context.AllAttributes.Where(c => c.Name.StartsWith("btn-"));
            var buttonTexts = context.AllAttributes.Where(c => c.Name.StartsWith("txt-"));
            var buttonGlyphs = context.AllAttributes.Where(c => c.Name.StartsWith("gly-"));
            var glyphsForAll = context.AllAttributes.FirstOrDefault(c => c.Name.Equals("glyphs")) != null;
            var buttonIds = context.AllAttributes.Where(c => c.Name.StartsWith("id-"));
            var globalId = context.AllAttributes.FirstOrDefault(c => c.Name.Equals("id"));
            foreach (var action in actions)
            {
                string actionName = action.Name.Substring(7);

                #region Button Type
                var buttonType = buttonTypes.FirstOrDefault(b => b.Name.StartsWith($"btn-{actionName}-"));
                var btnType = buttonType == null ? "default" : buttonType.Name.Substring(5 + actionName.Length);
                #endregion

                #region Button Text
                var buttonText = buttonTexts.FirstOrDefault(b => b.Name.StartsWith($"txt-{actionName}"));
                var btnText = buttonText == null ? string.Empty : buttonText.Value == null ? string.Empty : buttonText.Value.ToString();
                #endregion

                #region Glyphicon
                var glyph = string.Empty;
                if (glyphsForAll)
                {
                    glyph = ButtonGlyphs.FirstOrDefault(g => g.Key.ToUpper().Equals(actionName.ToUpper())).Value;
                }

                var specificGlyph = buttonGlyphs.FirstOrDefault(b => b.Name.StartsWith($"gly-{actionName}"));
                if (specificGlyph != null && specificGlyph.Value != null && !specificGlyph.Value.Equals(String.Empty))
                    glyph = specificGlyph.Value.ToString();
                #endregion

                #region Ids
                var ids = globalId == null ? string.Empty : $"id={globalId.Value}";
                foreach (var btnId in buttonIds)
                {
                    if (btnId.Value != null && !btnId.Value.Equals(string.Empty))
                    {
                        ids = $"{ids}&{btnId.Name.Substring(3)}={btnId.Value}";
                    }
                }
                if (ids.Substring(0, 1).Equals("&")) ids = ids.Substring(1);
                var param = $"?{ids}";
                #endregion

                #region Show/hide button text and Glyphicons
                var glyphClass = "";
                if (glyph.Length > 0) glyphClass += $" glyphicon glyphicon-{glyph}";
                if (glyph.Length > 0 && btnText.Length > 0) btnText = $"&nbsp{btnText}";
                #endregion

                #region Bootstrap buttona and URL
                var classAttr = $"btn-sm btn-{btnType}";
                var href = $@"/admin/{Controller}/{actionName}{param}";
                #endregion

                output.Content.AppendHtml(
                        $@"<a class='{classAttr}' href='{href}'><span class='{glyphClass}'></span>{btnText}</a>");
            }
            output.Content.AppendHtml("</span>");
        }
    }
}
