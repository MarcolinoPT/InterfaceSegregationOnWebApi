# InterfaceSegregationOnWebApi
An example of Interface Segregation Principle applied to ASP.NET Web API

This is based on a thread that I have been following for a while regarding the (over)use of the [IService pattern](http://blog.hovland.xyz/2017-04-22-stop-overusing-interfaces/#comment-4494832085).

This particular comment got me thinking that probably other developers are also aware of this but are not applying this pattern correctly.
I believe we should invest in SOLID as a whole and not apply just some of the principles because of convention, general practice by others,
or because of convenience.

Since SimpleInjector provides a nice functionality to avoid Torn Lifestyles I decided to put their example to test.

You will see that both approaches on code provide the same instance for both interfaces.
