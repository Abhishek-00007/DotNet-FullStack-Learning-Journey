import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

  const clonedRequest = req.clone({
    setHeaders: {
      Authorization: 'Bearer DummyToken123'
    }
  });

  return next(clonedRequest);
};