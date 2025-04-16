import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import LivroCaixaClientesInc from "../Inc/LivroCaixaClientes";
import { ILivroCaixaClientes } from "../../Interfaces/interface.LivroCaixaClientes";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { LivroCaixaClientesEmpty } from "@/app/GerAdv_TS/Models/LivroCaixaClientes";
import { useWindow } from "@/app/hooks/useWindows";

interface LivroCaixaClientesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedLivroCaixaClientes?: ILivroCaixaClientes;
    onSuccess: () => void;
    onError: () => void;
}

const LivroCaixaClientesWindow: React.FC<LivroCaixaClientesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedLivroCaixaClientes,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/livrocaixaclientes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedLivroCaixaClientes?.id}`);
        }

    }, [isMobile, router, selectedLivroCaixaClientes]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedLivroCaixaClientes?.id ?? 0).toString()}
                >
                    <LivroCaixaClientesInc
                        id={selectedLivroCaixaClientes?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowLivroCaixaClientes: React.FC<LivroCaixaClientesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <LivroCaixaClientesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedLivroCaixaClientes={LivroCaixaClientesEmpty()}>
        </LivroCaixaClientesWindow>
    )
};

export default LivroCaixaClientesWindow;