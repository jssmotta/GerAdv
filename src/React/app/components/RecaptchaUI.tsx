import { useEffect, useState } from 'react';
import {
  GoogleReCaptcha,
  GoogleReCaptchaProvider,
} from 'react-google-recaptcha-v3';
import verifyReCaptcha from '../auth/api/ReCaptchaApi';
 

interface RecaptchaUIProps {
  children: React.ReactNode;
  setCaptchaSuccess: any;
}

const RecaptchaUI = ({ children, setCaptchaSuccess }: RecaptchaUIProps) => {
  const [isLocalhost, setIsLocalhost] = useState(false);
  const [themeX, setTheme] = useState<'dark' | 'light'>('light');

  const handleVerify = (valueRecaptcha: any) => {
    const captchaValue = valueRecaptcha;

    if (
      process.env.NEXT_PUBLIC_RE3_BYPASS !== undefined &&
      process.env.NEXT_PUBLIC_RE3_BYPASS === '1'
    ) {
      setCaptchaSuccess(1);
      return;
    }

    verifyReCaptcha(captchaValue ?? '')
      .then((response) => {
        if (!response.success) {
          setCaptchaSuccess(2);
        } else {
          setCaptchaSuccess(1);
        }
      })
      .catch((error) => {
        console.error('Error:', error);
        setCaptchaSuccess(1);
      });
  };

  useEffect(() => {
    // Check if running on localhost

    var localHost = checkHost();

    setIsLocalhost(localHost);
    if (localHost) {
      setCaptchaSuccess(1);
    }
  }, []);

  const checkHost = (): boolean => {
    if (typeof window === 'undefined') return false;

    const hostname = window.location.hostname;
    return (
      hostname === 'localhost' ||
      hostname === '192.168.49.1' ||
      hostname === '127.0.0.1'
    );
  };

  useEffect(() => {
    const darkThemeMq = window.matchMedia('(prefers-color-scheme: dark)');

    const themeChangeHandler = (e: any) => {
      setTheme(e.matches ? 'dark' : 'light');
    };

    darkThemeMq.addEventListener('change', themeChangeHandler);

    setTheme(darkThemeMq.matches ? 'dark' : 'light');

    return () => {
      darkThemeMq.removeEventListener('change', themeChangeHandler);
    };
  }, []);

  return isLocalhost ||
    process.env.NEXT_PUBLIC_RECAPTCHA_SITE_KEY === undefined ? (
    <>{children}</>
  ) : (
    <>
      <GoogleReCaptchaProvider
        reCaptchaKey={process.env.NEXT_PUBLIC_RECAPTCHA_SITE_KEY || ''}
        language="pt-BR"
        useRecaptchaNet={true}
        useEnterprise={false}
        scriptProps={{
          async: false,
          defer: false,
          appendTo: 'head',
          nonce: undefined,
        }}
        container={{
          element: 'myCustomElement',
          parameters: {
            badge: 'bottomright',
            theme: themeX,
          },
        }}
      >
        {children}
        <div id="myCustomElement"></div>
        <GoogleReCaptcha onVerify={handleVerify} />
      </GoogleReCaptchaProvider>
    </>
  );
};

export default RecaptchaUI;
