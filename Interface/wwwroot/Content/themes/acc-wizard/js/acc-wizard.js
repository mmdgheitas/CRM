!(function (t, e, a, n) {
    "use strict";
    function s(a, s) {
        function i(e) {
            e &&
                e.length > 1 &&
                (t(s.sidebar, u)
                    .children("li")
                    .children("a[href='" + e + "']")
                    .parent("li")
                    .addClass(s.activeClass),
                    t(s.sidebar, u)
                        .children("li")
                        .children("a[href!='" + e + "']")
                        .parent("li")
                        .removeClass(s.activeClass));
        }
        function o() {
            if (s.addButtons)
                for (
                    var a = t("<div/>", { class: s.stepClass }).append(t("<button/>", { class: s.nextClasses, type: s.nextType, text: s.nextText })),
                    n = t("<div/>", { class: s.stepClass })
                        .append(t("<button/>", { class: s.backClasses, type: s.backType, text: s.backText }))
                        .append(" ")
                        .append(t("<button/>", { class: s.nextClasses, type: s.nextType, text: s.nextText })),
                    l = t("<div/>", { class: s.stepClass }).append(t("<button/>", { class: s.backClasses, type: s.backType, text: s.backText })),
                    o = t(".panel-collapse .panel-body", u),
                    c = o.length,
                    r = 0;
                    c > r;
                    r++
                )
                    0 === r ? t(o[0]).append(a) : r === c - 1 ? t(o[c - 1]).append(l) : t(o[r]).append(t(n).clone());
            s.autoScrolling && (d = e.location.hash),
                (d =
                    d ||
                    t(s.sidebar, u)
                        .children("li." + s.todoClass + ":first")
                        .children("a")
                        .attr("href") ||
                    t(s.sidebar, u).children("li:first").children("a").attr("href")),
                s.autoScrolling && (e.location.hash = d);
            var h = "#" + t(".panel-group", u)[0].id;
            t(".collapse", u).each(function () {
                t(this).collapse("#" + this.id === d ? (t(this).hasClass("in") ? { parent: h, toggle: !1 } : { parent: h, toggle: !0 }) : t(this).hasClass("in") ? { parent: h, toggle: !0 } : { parent: h, toggle: !1 });
            }),
                i(d),
                s.autoScrolling &&
                t(e).bind("hashchange", function () {
                    d !== e.location.hash && ((d = e.location.hash), t(".panel-collapse" + d, u).collapse("show"), i(d));
                }),
                t(".panel-title a").on("click", function () {
                    (d = t(this).attr("href")), i(d), s.autoScrolling && (e.location.hash = d);
                }),
                s.addButtons &&
                (t("." + s.stepClass, u)
                    .children("button[type='" + s.nextType + "']")
                    .click(function (a) {
                        a.preventDefault();
                        var n = t(this).parents(".panel-collapse")[0];
                        p("beforeNext", n);
                        var s = "#" + t(".panel-collapse", t(n).parents(".panel").next(".panel")[0])[0].id;
                        t(s).collapse("show"), p("onNext", n), (d = s), i(d), (e.location.hash = d);
                    }),
                    t("." + s.stepClass, u)
                        .children("button[type='" + s.backType + "']")
                        .click(function (a) {
                            a.preventDefault();
                            var n = t(this).parents(".panel-collapse")[0];
                            p("beforeBack", n);
                            var s = "#" + t(".panel-collapse", t(n).parents(".panel").prev(".panel")[0])[0].id;
                            t(s).collapse("show"), p("onBack", n), (d = s), i(d), (e.location.hash = d);
                        })),
                p("onInit");
        }
        function c(t, e) {
            return e ? void (s[t] = e) : s[t];
        }
        function r() {
            p("onDestroy");
        }
        function p(t) {
            if (s[t] !== n) {
                var e = s[t];
                return (arguments[0] = h), e.apply(this, arguments);
            }
        }
        var d,
            h = a,
            u = t(a);
        return (s = t.extend({}, t.fn[l].defaults, s)), o(), { option: c, destroy: r };
    }
    var l = "accwizard";
    (t.fn[l] = function (e) {
        if ("string" == typeof arguments[0]) {
            var a,
                i = arguments[0],
                o = Array.prototype.slice.call(arguments, 1);
            return (
                this.each(function () {
                    if (!t.data(this, "plugin_" + l) || "function" != typeof t.data(this, "plugin_" + l)[i]) throw new Error("Method " + i + " does not exist on jQuery." + l);
                    a = t.data(this, "plugin_" + l)[i].apply(this, o);
                }),
                a !== n ? a : this
            );
        }
        return "object" != typeof e && e
            ? void 0
            : this.each(function () {
                t.data(this, "plugin_" + l) || t.data(this, "plugin_" + l, new s(this, e));
            });
    }),
        (t.fn[l].defaults = {
            addButtons: !0,
            sidebar: ".acc-wizard-sidebar",
            activeClass: "acc-wizard-active",
            completedClass: "acc-wizard-completed",
            todoClass: "acc-wizard-todo",
            stepClass: "acc-wizard-step",
            nextText: "Next Step",
            backText: "Go Back",
            nextType: "submit",
            backType: "reset",
            nextClasses: "btn-next",
            backClasses: "btn-back",
            autoScrolling: !0,
            onNext: function () { },
            onBack: function () { },
            onInit: function () { },
            onDestroy: function () { },
        });
})(jQuery, window, document);
