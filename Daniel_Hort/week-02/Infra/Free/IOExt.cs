﻿using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Free;
using System.Threading.Tasks;
using Infra.Free;

public static class IOExt
{
    public static IO<A> IO<A>(this A a) =>
       new Return<A>(a);

    public static IO<B> Select<A, B>(this IO<A> m, Func<A, B> f) =>
            m.Bind(a => f(a).IO());
    public static IO<C> SelectMany<A, B, C>(this IO<A> m, Func<A, IO<B>> f, Func<A, B, C> project) =>
            m.Bind(a => f(a).Bind(b => project(a, b).IO()));
    public static IO<Unit> NewIO<O>(O op) => new IO<O, Unit, Unit>(op, IO);
    public static IO<R> NewIO<O, R>(O op) => new IO<O, R, R>(op, IO);
    public static IO<object> Ack(object input) => NewIO<object, object>(input);
    public static IO<S> Ask<S>() => NewIO<Unit, S>(Unit.Default);
    public static IO<Unit> EmptyIO() => NewIO<Unit>(Unit.Default);

}
