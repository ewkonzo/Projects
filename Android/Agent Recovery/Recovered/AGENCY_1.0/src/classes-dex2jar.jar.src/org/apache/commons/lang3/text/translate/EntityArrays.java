package org.apache.commons.lang3.text.translate;

import java.lang.reflect.Array;

public class EntityArrays
{
  private static final String[][] APOS_ESCAPE;
  private static final String[][] APOS_UNESCAPE;
  private static final String[][] BASIC_ESCAPE;
  private static final String[][] BASIC_UNESCAPE;
  private static final String[][] HTML40_EXTENDED_ESCAPE;
  private static final String[][] HTML40_EXTENDED_UNESCAPE;
  private static final String[][] ISO8859_1_ESCAPE;
  private static final String[][] ISO8859_1_UNESCAPE;
  private static final String[][] JAVA_CTRL_CHARS_ESCAPE;
  private static final String[][] JAVA_CTRL_CHARS_UNESCAPE = invert(JAVA_CTRL_CHARS_ESCAPE);
  
  static
  {
    String[] arrayOfString1 = { " ", "&nbsp;" };
    String[] arrayOfString2 = { "¡", "&iexcl;" };
    String[] arrayOfString3 = { "¢", "&cent;" };
    String[] arrayOfString4 = { "£", "&pound;" };
    String[] arrayOfString5 = { "¥", "&yen;" };
    String[] arrayOfString6 = { "¦", "&brvbar;" };
    String[] arrayOfString7 = { "§", "&sect;" };
    String[] arrayOfString8 = { "©", "&copy;" };
    String[] arrayOfString9 = { "ª", "&ordf;" };
    String[] arrayOfString10 = { "«", "&laquo;" };
    String[] arrayOfString11 = { "¬", "&not;" };
    String[] arrayOfString12 = { "­", "&shy;" };
    String[] arrayOfString13 = { "®", "&reg;" };
    String[] arrayOfString14 = { "¯", "&macr;" };
    String[] arrayOfString15 = { "°", "&deg;" };
    String[] arrayOfString16 = { "±", "&plusmn;" };
    String[] arrayOfString17 = { "³", "&sup3;" };
    String[] arrayOfString18 = { "´", "&acute;" };
    String[] arrayOfString19 = { "µ", "&micro;" };
    String[] arrayOfString20 = { "¶", "&para;" };
    String[] arrayOfString21 = { "¹", "&sup1;" };
    String[] arrayOfString22 = { "»", "&raquo;" };
    String[] arrayOfString23 = { "¼", "&frac14;" };
    String[] arrayOfString24 = { "½", "&frac12;" };
    String[] arrayOfString25 = { "¿", "&iquest;" };
    String[] arrayOfString26 = { "À", "&Agrave;" };
    String[] arrayOfString27 = { "Á", "&Aacute;" };
    String[] arrayOfString28 = { "Ã", "&Atilde;" };
    String[] arrayOfString29 = { "Ä", "&Auml;" };
    String[] arrayOfString30 = { "Å", "&Aring;" };
    String[] arrayOfString31 = { "Æ", "&AElig;" };
    String[] arrayOfString32 = { "Ç", "&Ccedil;" };
    String[] arrayOfString33 = { "È", "&Egrave;" };
    String[] arrayOfString34 = { "É", "&Eacute;" };
    String[] arrayOfString35 = { "Ê", "&Ecirc;" };
    String[] arrayOfString36 = { "Ë", "&Euml;" };
    String[] arrayOfString37 = { "Ì", "&Igrave;" };
    String[] arrayOfString38 = { "Í", "&Iacute;" };
    String[] arrayOfString39 = { "Î", "&Icirc;" };
    String[] arrayOfString40 = { "Ï", "&Iuml;" };
    String[] arrayOfString41 = { "Ð", "&ETH;" };
    String[] arrayOfString42 = { "Ò", "&Ograve;" };
    String[] arrayOfString43 = { "Ó", "&Oacute;" };
    String[] arrayOfString44 = { "Ô", "&Ocirc;" };
    String[] arrayOfString45 = { "Õ", "&Otilde;" };
    String[] arrayOfString46 = { "×", "&times;" };
    String[] arrayOfString47 = { "Ø", "&Oslash;" };
    String[] arrayOfString48 = { "Ú", "&Uacute;" };
    String[] arrayOfString49 = { "Û", "&Ucirc;" };
    String[] arrayOfString50 = { "Þ", "&THORN;" };
    String[] arrayOfString51 = { "â", "&acirc;" };
    String[] arrayOfString52 = { "ã", "&atilde;" };
    String[] arrayOfString53 = { "å", "&aring;" };
    String[] arrayOfString54 = { "æ", "&aelig;" };
    String[] arrayOfString55 = { "ç", "&ccedil;" };
    String[] arrayOfString56 = { "è", "&egrave;" };
    String[] arrayOfString57 = { "é", "&eacute;" };
    String[] arrayOfString58 = { "ê", "&ecirc;" };
    String[] arrayOfString59 = { "ë", "&euml;" };
    String[] arrayOfString60 = { "í", "&iacute;" };
    String[] arrayOfString61 = { "î", "&icirc;" };
    String[] arrayOfString62 = { "ð", "&eth;" };
    String[] arrayOfString63 = { "ñ", "&ntilde;" };
    String[] arrayOfString64 = { "ò", "&ograve;" };
    String[] arrayOfString65 = { "ó", "&oacute;" };
    String[] arrayOfString66 = { "ô", "&ocirc;" };
    String[] arrayOfString67 = { "õ", "&otilde;" };
    String[] arrayOfString68 = { "ö", "&ouml;" };
    String[] arrayOfString69 = { "÷", "&divide;" };
    String[] arrayOfString70 = { "ù", "&ugrave;" };
    String[] arrayOfString71 = { "ú", "&uacute;" };
    String[] arrayOfString72 = { "ü", "&uuml;" };
    String[] arrayOfString73 = { "ý", "&yacute;" };
    String[] arrayOfString74 = { "þ", "&thorn;" };
    String[] arrayOfString75 = { "ÿ", "&yuml;" };
    ISO8859_1_ESCAPE = new String[][] { arrayOfString1, arrayOfString2, arrayOfString3, arrayOfString4, { "¤", "&curren;" }, arrayOfString5, arrayOfString6, arrayOfString7, { "¨", "&uml;" }, arrayOfString8, arrayOfString9, arrayOfString10, arrayOfString11, arrayOfString12, arrayOfString13, arrayOfString14, arrayOfString15, arrayOfString16, { "²", "&sup2;" }, arrayOfString17, arrayOfString18, arrayOfString19, arrayOfString20, { "·", "&middot;" }, { "¸", "&cedil;" }, arrayOfString21, { "º", "&ordm;" }, arrayOfString22, arrayOfString23, arrayOfString24, { "¾", "&frac34;" }, arrayOfString25, arrayOfString26, arrayOfString27, { "Â", "&Acirc;" }, arrayOfString28, arrayOfString29, arrayOfString30, arrayOfString31, arrayOfString32, arrayOfString33, arrayOfString34, arrayOfString35, arrayOfString36, arrayOfString37, arrayOfString38, arrayOfString39, arrayOfString40, arrayOfString41, { "Ñ", "&Ntilde;" }, arrayOfString42, arrayOfString43, arrayOfString44, arrayOfString45, { "Ö", "&Ouml;" }, arrayOfString46, arrayOfString47, { "Ù", "&Ugrave;" }, arrayOfString48, arrayOfString49, { "Ü", "&Uuml;" }, { "Ý", "&Yacute;" }, arrayOfString50, { "ß", "&szlig;" }, { "à", "&agrave;" }, { "á", "&aacute;" }, arrayOfString51, arrayOfString52, { "ä", "&auml;" }, arrayOfString53, arrayOfString54, arrayOfString55, arrayOfString56, arrayOfString57, arrayOfString58, arrayOfString59, { "ì", "&igrave;" }, arrayOfString60, arrayOfString61, { "ï", "&iuml;" }, arrayOfString62, arrayOfString63, arrayOfString64, arrayOfString65, arrayOfString66, arrayOfString67, arrayOfString68, arrayOfString69, { "ø", "&oslash;" }, arrayOfString70, arrayOfString71, { "û", "&ucirc;" }, arrayOfString72, arrayOfString73, arrayOfString74, arrayOfString75 };
    ISO8859_1_UNESCAPE = invert(ISO8859_1_ESCAPE);
    arrayOfString1 = new String[] { "ƒ", "&fnof;" };
    arrayOfString2 = new String[] { "Β", "&Beta;" };
    arrayOfString3 = new String[] { "Γ", "&Gamma;" };
    arrayOfString4 = new String[] { "Δ", "&Delta;" };
    arrayOfString5 = new String[] { "Ε", "&Epsilon;" };
    arrayOfString6 = new String[] { "Θ", "&Theta;" };
    arrayOfString7 = new String[] { "Κ", "&Kappa;" };
    arrayOfString8 = new String[] { "Ν", "&Nu;" };
    arrayOfString9 = new String[] { "Τ", "&Tau;" };
    arrayOfString10 = new String[] { "Υ", "&Upsilon;" };
    arrayOfString11 = new String[] { "Ψ", "&Psi;" };
    arrayOfString12 = new String[] { "β", "&beta;" };
    arrayOfString13 = new String[] { "ε", "&epsilon;" };
    arrayOfString14 = new String[] { "ι", "&iota;" };
    arrayOfString15 = new String[] { "κ", "&kappa;" };
    arrayOfString16 = new String[] { "ν", "&nu;" };
    arrayOfString17 = new String[] { "ξ", "&xi;" };
    arrayOfString18 = new String[] { "ς", "&sigmaf;" };
    arrayOfString19 = new String[] { "τ", "&tau;" };
    arrayOfString20 = new String[] { "ϑ", "&thetasym;" };
    arrayOfString21 = new String[] { "•", "&bull;" };
    arrayOfString22 = new String[] { "…", "&hellip;" };
    arrayOfString23 = new String[] { "″", "&Prime;" };
    arrayOfString24 = new String[] { "ℑ", "&image;" };
    arrayOfString25 = new String[] { "ℜ", "&real;" };
    arrayOfString26 = new String[] { "ℵ", "&alefsym;" };
    arrayOfString27 = new String[] { "↑", "&uarr;" };
    arrayOfString28 = new String[] { "→", "&rarr;" };
    arrayOfString29 = new String[] { "↓", "&darr;" };
    arrayOfString30 = new String[] { "↔", "&harr;" };
    arrayOfString31 = new String[] { "↵", "&crarr;" };
    arrayOfString32 = new String[] { "⇐", "&lArr;" };
    arrayOfString33 = new String[] { "⇑", "&uArr;" };
    arrayOfString34 = new String[] { "∀", "&forall;" };
    arrayOfString35 = new String[] { "∂", "&part;" };
    arrayOfString36 = new String[] { "∅", "&empty;" };
    arrayOfString37 = new String[] { "∇", "&nabla;" };
    arrayOfString38 = new String[] { "∈", "&isin;" };
    arrayOfString39 = new String[] { "∉", "&notin;" };
    arrayOfString40 = new String[] { "∗", "&lowast;" };
    arrayOfString41 = new String[] { "√", "&radic;" };
    arrayOfString42 = new String[] { "∝", "&prop;" };
    arrayOfString43 = new String[] { "∩", "&cap;" };
    arrayOfString44 = new String[] { "∪", "&cup;" };
    arrayOfString45 = new String[] { "∴", "&there4;" };
    arrayOfString46 = new String[] { "∼", "&sim;" };
    arrayOfString47 = new String[] { "≅", "&cong;" };
    arrayOfString48 = new String[] { "≈", "&asymp;" };
    arrayOfString49 = new String[] { "≠", "&ne;" };
    arrayOfString50 = new String[] { "≡", "&equiv;" };
    arrayOfString51 = new String[] { "⊂", "&sub;" };
    arrayOfString52 = new String[] { "⊕", "&oplus;" };
    arrayOfString53 = new String[] { "⊗", "&otimes;" };
    arrayOfString54 = new String[] { "⊥", "&perp;" };
    arrayOfString55 = new String[] { "⌈", "&lceil;" };
    arrayOfString56 = new String[] { "⌉", "&rceil;" };
    arrayOfString57 = new String[] { "〈", "&lang;" };
    arrayOfString58 = new String[] { "◊", "&loz;" };
    arrayOfString59 = new String[] { "♣", "&clubs;" };
    arrayOfString60 = new String[] { "♥", "&hearts;" };
    arrayOfString61 = new String[] { "♦", "&diams;" };
    arrayOfString62 = new String[] { "Œ", "&OElig;" };
    arrayOfString63 = new String[] { "œ", "&oelig;" };
    arrayOfString64 = new String[] { "ˆ", "&circ;" };
    arrayOfString65 = new String[] { " ", "&ensp;" };
    arrayOfString66 = new String[] { "‌", "&zwnj;" };
    arrayOfString67 = new String[] { "‍", "&zwj;" };
    arrayOfString68 = new String[] { "‎", "&lrm;" };
    arrayOfString69 = new String[] { "–", "&ndash;" };
    arrayOfString70 = new String[] { "‚", "&sbquo;" };
    arrayOfString71 = new String[] { "”", "&rdquo;" };
    arrayOfString72 = new String[] { "„", "&bdquo;" };
    arrayOfString73 = new String[] { "‡", "&Dagger;" };
    arrayOfString74 = new String[] { "‹", "&lsaquo;" };
    arrayOfString75 = new String[] { "€", "&euro;" };
    HTML40_EXTENDED_ESCAPE = new String[][] { arrayOfString1, { "Α", "&Alpha;" }, arrayOfString2, arrayOfString3, arrayOfString4, arrayOfString5, { "Ζ", "&Zeta;" }, { "Η", "&Eta;" }, arrayOfString6, { "Ι", "&Iota;" }, arrayOfString7, { "Λ", "&Lambda;" }, { "Μ", "&Mu;" }, arrayOfString8, { "Ξ", "&Xi;" }, { "Ο", "&Omicron;" }, { "Π", "&Pi;" }, { "Ρ", "&Rho;" }, { "Σ", "&Sigma;" }, arrayOfString9, arrayOfString10, { "Φ", "&Phi;" }, { "Χ", "&Chi;" }, arrayOfString11, { "Ω", "&Omega;" }, { "α", "&alpha;" }, arrayOfString12, { "γ", "&gamma;" }, { "δ", "&delta;" }, arrayOfString13, { "ζ", "&zeta;" }, { "η", "&eta;" }, { "θ", "&theta;" }, arrayOfString14, arrayOfString15, { "λ", "&lambda;" }, { "μ", "&mu;" }, arrayOfString16, arrayOfString17, { "ο", "&omicron;" }, { "π", "&pi;" }, { "ρ", "&rho;" }, arrayOfString18, { "σ", "&sigma;" }, arrayOfString19, { "υ", "&upsilon;" }, { "φ", "&phi;" }, { "χ", "&chi;" }, { "ψ", "&psi;" }, { "ω", "&omega;" }, arrayOfString20, { "ϒ", "&upsih;" }, { "ϖ", "&piv;" }, arrayOfString21, arrayOfString22, { "′", "&prime;" }, arrayOfString23, { "‾", "&oline;" }, { "⁄", "&frasl;" }, { "℘", "&weierp;" }, arrayOfString24, arrayOfString25, { "™", "&trade;" }, arrayOfString26, { "←", "&larr;" }, arrayOfString27, arrayOfString28, arrayOfString29, arrayOfString30, arrayOfString31, arrayOfString32, arrayOfString33, { "⇒", "&rArr;" }, { "⇓", "&dArr;" }, { "⇔", "&hArr;" }, arrayOfString34, arrayOfString35, { "∃", "&exist;" }, arrayOfString36, arrayOfString37, arrayOfString38, arrayOfString39, { "∋", "&ni;" }, { "∏", "&prod;" }, { "∑", "&sum;" }, { "−", "&minus;" }, arrayOfString40, arrayOfString41, arrayOfString42, { "∞", "&infin;" }, { "∠", "&ang;" }, { "∧", "&and;" }, { "∨", "&or;" }, arrayOfString43, arrayOfString44, { "∫", "&int;" }, arrayOfString45, arrayOfString46, arrayOfString47, arrayOfString48, arrayOfString49, arrayOfString50, { "≤", "&le;" }, { "≥", "&ge;" }, arrayOfString51, { "⊃", "&sup;" }, { "⊆", "&sube;" }, { "⊇", "&supe;" }, arrayOfString52, arrayOfString53, arrayOfString54, { "⋅", "&sdot;" }, arrayOfString55, arrayOfString56, { "⌊", "&lfloor;" }, { "⌋", "&rfloor;" }, arrayOfString57, { "〉", "&rang;" }, arrayOfString58, { "♠", "&spades;" }, arrayOfString59, arrayOfString60, arrayOfString61, arrayOfString62, arrayOfString63, { "Š", "&Scaron;" }, { "š", "&scaron;" }, { "Ÿ", "&Yuml;" }, arrayOfString64, { "˜", "&tilde;" }, arrayOfString65, { " ", "&emsp;" }, { " ", "&thinsp;" }, arrayOfString66, arrayOfString67, arrayOfString68, { "‏", "&rlm;" }, arrayOfString69, { "—", "&mdash;" }, { "‘", "&lsquo;" }, { "’", "&rsquo;" }, arrayOfString70, { "“", "&ldquo;" }, arrayOfString71, arrayOfString72, { "†", "&dagger;" }, arrayOfString73, { "‰", "&permil;" }, arrayOfString74, { "›", "&rsaquo;" }, arrayOfString75 };
    HTML40_EXTENDED_UNESCAPE = invert(HTML40_EXTENDED_ESCAPE);
    arrayOfString1 = new String[] { "<", "&lt;" };
    BASIC_ESCAPE = new String[][] { { "\"", "&quot;" }, { "&", "&amp;" }, arrayOfString1, { ">", "&gt;" } };
    BASIC_UNESCAPE = invert(BASIC_ESCAPE);
    APOS_ESCAPE = new String[][] { { "'", "&apos;" } };
    APOS_UNESCAPE = invert(APOS_ESCAPE);
    arrayOfString1 = new String[] { "\b", "\\b" };
    arrayOfString2 = new String[] { "\t", "\\t" };
    arrayOfString3 = new String[] { "\r", "\\r" };
    JAVA_CTRL_CHARS_ESCAPE = new String[][] { arrayOfString1, { "\n", "\\n" }, arrayOfString2, { "\f", "\\f" }, arrayOfString3 };
  }
  
  public static String[][] APOS_ESCAPE()
  {
    return (String[][])APOS_ESCAPE.clone();
  }
  
  public static String[][] APOS_UNESCAPE()
  {
    return (String[][])APOS_UNESCAPE.clone();
  }
  
  public static String[][] BASIC_ESCAPE()
  {
    return (String[][])BASIC_ESCAPE.clone();
  }
  
  public static String[][] BASIC_UNESCAPE()
  {
    return (String[][])BASIC_UNESCAPE.clone();
  }
  
  public static String[][] HTML40_EXTENDED_ESCAPE()
  {
    return (String[][])HTML40_EXTENDED_ESCAPE.clone();
  }
  
  public static String[][] HTML40_EXTENDED_UNESCAPE()
  {
    return (String[][])HTML40_EXTENDED_UNESCAPE.clone();
  }
  
  public static String[][] ISO8859_1_ESCAPE()
  {
    return (String[][])ISO8859_1_ESCAPE.clone();
  }
  
  public static String[][] ISO8859_1_UNESCAPE()
  {
    return (String[][])ISO8859_1_UNESCAPE.clone();
  }
  
  public static String[][] JAVA_CTRL_CHARS_ESCAPE()
  {
    return (String[][])JAVA_CTRL_CHARS_ESCAPE.clone();
  }
  
  public static String[][] JAVA_CTRL_CHARS_UNESCAPE()
  {
    return (String[][])JAVA_CTRL_CHARS_UNESCAPE.clone();
  }
  
  public static String[][] invert(String[][] paramArrayOfString)
  {
    String[][] arrayOfString = (String[][])Array.newInstance(String.class, new int[] { paramArrayOfString.length, 2 });
    int i = 0;
    while (i < paramArrayOfString.length)
    {
      arrayOfString[i][0] = paramArrayOfString[i][1];
      arrayOfString[i][1] = paramArrayOfString[i][0];
      i += 1;
    }
    return arrayOfString;
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\org\apache\commons\lang3\text\translate\EntityArrays.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */