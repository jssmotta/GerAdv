'use client';
import { useAppDispatch, useAppSelector } from '@/app/store/hooks';
import { selectSystemContext, setLoginEmail, setSystemContext } from '@/app/store/slices/systemContextSlice';
import ChangePassword from '../ChangePassword';
import { useRouter } from 'next/navigation';
import GAComponent from '@/app/tools/GA';
import HotjarComponent from '@/app/tools/Hotjar'; 
import React, { useEffect } from 'react';
import { useAuth } from '../AuthProvider';
import { useSecureNavigation } from '../hooks/useSecureNavigation';
import StylesLogin from '../StylesLogin';
import { MustChangePasswordChecked } from '../tools/userControl';
import DarkModeCss from '@/app/components/msi/DarkModeCss';
import './cp.css';
export default function CpPage() {
  
  const router = useRouter();
  const dispatch = useAppDispatch();
  const systemContext = useAppSelector(selectSystemContext);
  const [readCurrentPassword ] = React.useState(true);
  const { logout } = useAuth();
  const { secureNavigate } = useSecureNavigation();

  useEffect(() => {
    if (typeof window === 'undefined') return;

    const APP_ID = process.env.NEXT_PUBLIC_APP_GLOBAL ?? 'APP_ID';

    try {
      // restore systemContext if missing
      if (!systemContext) {
        const saved = localStorage.getItem(btoa(`${APP_ID}systemContext`));
        if (saved) {
          const parsed = JSON.parse(saved);
          dispatch(setSystemContext(parsed));
        }
      }

      // restore loginEmail if missing
      const savedEmail = localStorage.getItem(btoa(`${APP_ID}loginEmail0`));
      if (savedEmail) {
        try {
          const parsedEmail = JSON.parse(savedEmail);
          // setLoginEmail will update context and localStorage
          dispatch(setLoginEmail(parsedEmail));
        } catch (e) {
          // ignore parse errors
        }
      }
    } catch (err) {
      // ignore errors here; this is a best-effort restore
    }
  }, []);

  return (
    <>
    <DarkModeCss />
    <StylesLogin force={true} />
      <GAComponent />
      
 

      <div className="login-container">
        <div className="login-form">
          <div
            className="login-logo-image"
            style={{ backgroundImage: "url('/images/Logo64.webp')" }}
          ></div>

          <div className="login-prod-text">
            {process.env.NEXT_PUBLIC_NOME_PRODUTO}
          </div>

          <ChangePassword
            readCurrentPassword={readCurrentPassword && !MustChangePasswordChecked()}
            onSuccess={() => {              
              logout();
              dispatch(setLoginEmail(null));
              dispatch(setSystemContext(null));
              secureNavigate('/auth', { replace: true });
              router.refresh();
            }}
            onCancel={() => {              
              secureNavigate('/dashboard', { replace: true });
            }}
          />
          <div className="login-footer">
            <div className="footer-text">
              Menphis - Sistemas Inteligentes
              <br />
              <br />
              Desde 1996
              <br />
              <a
                className="linkEmpresa"
                href="https://www.menphis.com.br/"
                target="_blank"
                rel="noopener noreferrer"
              >
                www.menphis.com.br
              </a>
              <br />
              <a
                className="linkEmpresa"
                href={`https://api.whatsapp.com/send?phone=${process.env.NEXT_PUBLIC_WHATSAPP_NUMBER}&text=Ol%C3%A1,%20tudo%20bem???`}
                target="_blank"
                rel="noopener noreferrer"
              >
                Suporte
              </a>
            </div>
          </div>

          <div className="login-footer show-footer">
            <div className="footer-text">
              <a
                className="linkEmpresa"
                href="https://www.menphis.com.br/"
                target="_blank"
                rel="noopener noreferrer"
              >
                www.menphis.com.br
              </a>
              &nbsp;|&nbsp;
              <a
                className="linkEmpresa"
                href={`https://api.whatsapp.com/send?phone=${process.env.NEXT_PUBLIC_WHATSAPP_NUMBER}&text=Ol%C3%A1,%20tudo%20bem???`}
                target="_blank"
                rel="noopener noreferrer"
              >
                Suporte
              </a>
            </div>

            <div
              className="footer-powered"
              onClick={() => window.open('https://www.telerik.com/kendo-react-ui', '_blank')}
            >
              Powered by Telerik<br></br>
              <img
                width={16}
                src="https://telerik.com/favicon.ico"
                alt="Telerik"
                className="telerik-logo"
                style={{ cursor: 'pointer' }}
              />
            </div>
            <div className="footer-text-legal">
              ©1996-202 Menphis Sistemas Inteligentes - Todos os direitos
              reservados.
            </div>
          </div>
        </div>
        <div
          className="login-image"
          style={{ backgroundImage: `url('../../images/fundoApp${process.env.NEXT_PUBLIC_BK_SEXO}.webp')` }}
        ></div>
      </div>

      <HotjarComponent />
    </>
  );
}
