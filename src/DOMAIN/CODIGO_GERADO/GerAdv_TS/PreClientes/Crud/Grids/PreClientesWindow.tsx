import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import PreClientesInc from "../Inc/PreClientes";
import { IPreClientes } from "../../Interfaces/interface.PreClientes";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { PreClientesEmpty } from "@/app/GerAdv_TS/Models/PreClientes";
import { useWindow } from "@/app/hooks/useWindows";

interface PreClientesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedPreClientes?: IPreClientes;
    onSuccess: () => void;
    onError: () => void;
}

const PreClientesWindow: React.FC<PreClientesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedPreClientes,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/preclientes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedPreClientes?.id}`);
        }

    }, [isMobile, router, selectedPreClientes]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedPreClientes?.id ?? 0).toString()}
                >
                    <PreClientesInc
                        id={selectedPreClientes?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowPreClientes: React.FC<PreClientesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <PreClientesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedPreClientes={PreClientesEmpty()}>
        </PreClientesWindow>
    )
};

export default PreClientesWindow;