import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import EnderecoSistemaInc from "../Inc/EnderecoSistema";
import { IEnderecoSistema } from "../../Interfaces/interface.EnderecoSistema";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { EnderecoSistemaEmpty } from "@/app/GerAdv_TS/Models/EnderecoSistema";
import { useWindow } from "@/app/hooks/useWindows";

interface EnderecoSistemaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedEnderecoSistema?: IEnderecoSistema;
    onSuccess: () => void;
    onError: () => void;
}

const EnderecoSistemaWindow: React.FC<EnderecoSistemaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedEnderecoSistema,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/enderecosistema/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedEnderecoSistema?.id}`);
        }

    }, [isMobile, router, selectedEnderecoSistema]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={657}
                    newWidth={1440}
                    id={(selectedEnderecoSistema?.id ?? 0).toString()}
                >
                    <EnderecoSistemaInc
                        id={selectedEnderecoSistema?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowEnderecoSistema: React.FC<EnderecoSistemaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <EnderecoSistemaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedEnderecoSistema={EnderecoSistemaEmpty()}>
        </EnderecoSistemaWindow>
    )
};

export default EnderecoSistemaWindow;