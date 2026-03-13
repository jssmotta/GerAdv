'use client';

import { Loader } from '@progress/kendo-react-indicators';
import React from 'react'; 
import LoginStyle from './StylesLogin';
import LoadingAnimation from './tools/LoadingAnimation';

const SplashLogin: React.FC = () => {
  return (
    <>
      <LoginStyle force={false} />
      <style>
        {`
              body { 
                background-size: cover; 
                background-repeat: no-repeat; 
                background-image: url('/images/fundoApp${process.env.NEXT_PUBLIC_BK_SEXO}.webp'); 
                background-attachment: fixed; 
                margin: 0;
                padding: 0;
                width: 100%; 
                height: 100vh;
              } 
    
              .background-image {
                display: flex;
                flex-direction: column;
                align-items: center;
                justify-content: flex-start;
                height: 100vh;
                background: none;
              }
    
              .system-name {
                margin-top: 20px;
                font-size: 30pt;
                text-align: center;
                color: #fff;
              }
    
              footer { 
                position: fixed; 
                bottom: 10px; 
                left: 50%; 
                transform: translateX(-50%);
                font-size: 16px;
                color: black;
              }
    
              .loading-dashboard { 
                width: 100%; 
                display: flex; 
                justify-content: center; 
                align-items: center; 
                height: calc(100vh - 100px);
              }
    
              @media (max-width: 768px) {
                body {
                  background-position: center; 
                }
                .background-image {
                  margin-top: -40%;
                }
                .system-name {
                  margin-top: 30vh;
                }
              }
            `}
      </style>
      <div className="background-image">
        <div className="system-name">
          {process.env.NEXT_PUBLIC_NOME_PRODUTO}
        </div>
        <div className="loading-dashboard flex items-center justify-center h-screen">
          <Loader size="large" type={'converging-spinner'} />
        </div>
        <footer><LoadingAnimation text='Pensando...' /></footer>
      </div>
    </>
  );
};

export default SplashLogin;
