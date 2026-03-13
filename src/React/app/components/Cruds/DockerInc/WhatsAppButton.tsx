'use client';
import React from 'react';
import { useIsMobile } from '@/app/context/MobileContext';

interface WhatsAppButtonProps {
    tableTitle?: string;
    phone?: string;
    message?: string;
}

const WhatsAppButton: React.FC<WhatsAppButtonProps> = ({
    tableTitle = 'este formulário',
    phone,
    message
}) => {
    const isMobile = useIsMobile();

    const whatsappPhone = phone || process.env.NEXT_PUBLIC_WHATSAPP_NUMBER;
    const whatsappMessage = message || `Olá, tudo bem, preciso de suporte com a edição de ${tableTitle}?`;
    const whatsappUrl = `https://api.whatsapp.com/send?phone=${whatsappPhone}&text=${encodeURIComponent(whatsappMessage)}`;

    return (
        <a
            target="_blank"
            rel="noopener noreferrer"
            href={whatsappUrl}
            title='Abra o WhatsApp para enviar uma mensagem ao suporte deste produto'
            id="botao-whatsapp"
            style={{
                display: 'inline-flex',
                alignItems: 'center',
                justifyContent: 'center',
                width: '18px',
                height: '18px',
                cursor: 'pointer'
            }}
        >
            <img
                src={process.env.NEXT_PUBLIC_LOGO_CONTATO}
                alt="WhatsApp"
                style={{ width: '18px', height: '18px' }}
            />
        </a>
    );
};

export default WhatsAppButton;