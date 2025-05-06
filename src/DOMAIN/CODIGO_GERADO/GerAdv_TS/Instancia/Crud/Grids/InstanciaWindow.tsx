import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import InstanciaInc from "../Inc/Instancia";
import { IInstancia } from "../../Interfaces/interface.Instancia";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { InstanciaEmpty } from "@/app/GerAdv_TS/Models/Instancia";
import { useWindow } from "@/app/hooks/useWindows";

interface InstanciaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedInstancia?: IInstancia;
    onSuccess: () => void;
    onError: () => void;
}

const InstanciaWindow: React.FC<InstanciaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedInstancia,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/instancia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedInstancia?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedInstancia]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={834}
                    newWidth={1440}
                    id={(selectedInstancia?.id ?? 0).toString()}
                >
                    <InstanciaInc
                        id={selectedInstancia?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowInstancia: React.FC<InstanciaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <InstanciaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedInstancia={InstanciaEmpty()}>
        </InstanciaWindow>
    )
};

export default InstanciaWindow;