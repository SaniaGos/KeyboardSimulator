using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardSimulator
{
    public static class Text
    {
        static List<string> listUA = new List<string>()
        {
            "аафф ілді ожжд ілді аафф ілді ожжд ілді аафф ілді ожжді",
            "оаоо фддо одад оаоо оаоо фддо одад оаоо оаоо фддо одадо",
            "івфв афвф лжов алдд івфв афвф лжов алдд івфв афвф лжовд",
            "два два два ода ода ода два два два ода ода ода ода два",
            "три три чотири чотири три два один чотири чотири тр три",

            "далі діло діва філіал доволі водовідвід водовідвід долі",
            "паж родовід раж полір дрож долар паж родовід раж полірр",
            "драп радіо відпад попіл пава плов драп радіо відпад пол",
            "порфіра лопар флопі ропа поло орда порфіра лопар флопіо",
            "підвода попіл фавор дар рожа двір підвода попіл фаводар",

            "Та нині він знову капітан. Дотепер жили вони в згоді...",
            "Правда гірка, але здорова. Проте, полковник зволікав...",
            "Він підносить руку й просить уваги. І не тільки жити...",
            "а рости, ширитись. Нас радо зустріли, посадили за стіл.",
            "Не сама була на місті, поблизу воріт. Мені треба привіт",

            "Я три дні не міг отямитися після відвідання того музею.",
            "І я не вийду з корабля, поки не довідаюся, в чім тут рі",
            "Це найкращий проповідник з усіх, що я чув. У зоні працю",
            "У зоні працювали на якихсь легких роботах. А то ж хіба ",
            "А чи в мене є час роз'їжджати сюди-туди. Перший  осені.",

            "Рівень злочинності за 2012рік на 10тис.   складає 169,4",
            "Коли говориться про \"зростання на 10%\" або \"м на 20%",
            "Вважається, що зміна відбувається порівняно з попереднь",
            "Зірочка або астеріск - друкарський знак у вигляді невел",
            "п'яти-або шестикутної зірочки (*), розташованої в рядку"
        };
        static List<string> listEN = new List<string>()
        {
            "aa ss dd ff jj kk ll ;; aa ss dd ff jj kk ll ;; aa ss d",
            "ad ad jk jk ad ad jk jk ad ad jk jk ad ad jk jk ad ad j",
            "afsd afsd j;kl j;kl afsd afsd j;kl j;kl afsd afsd j;kl ",
            "dsak dsak jkfl jkfl dsak dsak jkfl jkfl dsak dsak jkfl ",
            "add add add add add add add add add add add add add add",

            "confine confine, cone cone. confine confine, cone cone.",
            "recon recon, inced inced. recon recon, inced inced. rec",
            "loafs, recluses, asdic, ions, cowardliness. loafs, recl",
            "reconsider, ruefulness, curious, denied, druidical. rec",
            "lousier. dalasi. uncial. ecce. ads lousier. dalasi. unc",

            "diversiform serviceman velum venomousness commove venum",
            "moviemaker vermicelli vernacularism vacuumed mediaeval ",
            "nevermore verisimilar duumvir microwaves voluminous mar",
            "mendelevium missive commoves vanadium commoved Maldive ",
            "envenom venom mover emissive overcame microwave misconc",

            "He must go to her. He had never seen her anywhere else.",
            "Are you hungry. He delivered the goods. He was glad. ..",
            "He sighed heavily. The high card won. Suggest something",
            "Therefore they fought the light. He is a light for figh",
            "What are you going to do with it. I had a very delightf",

            "Certain shorthand date formats use / as a delimiter, 21",
            "as a delimiter, for example \"6/21/1788\" June 21, 1788. ",
            "Certain prefixes (co-, pre-, mid-, de-, non-, anti-, et",
            "may or may not be hyphenated. Hyphens are occasionally ",
            " to denote syllabification, as in syl-la-bi-fi-ca-tion."

        };
        public static string GetText(int difficulty, MyLanguage language)
        {
            if (language == MyLanguage.Ukrainian)
                return listUA[MyRand.GetRand(0,4) + (difficulty - 1) * 5];
            else return listEN[MyRand.GetRand(0, 4) + (difficulty - 1) * 5];
        }
    }
}
