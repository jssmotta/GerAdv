import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProcessosInc from "../Inc/Processos";
import { IProcessos } from "../../Interfaces/interface.Processos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProcessosEmpty } from "@/app/GerAdv_TS/Models/Processos";
import { useWindow } from "@/app/hooks/useWindows";

interface ProcessosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProcessos?: IProcessos;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessosWindow: React.FC<ProcessosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProcessos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/processos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProcessos?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProcessos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedProcessos?.id ?? 0).toString()}
                >
                    <ProcessosInc
                        id={selectedProcessos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProcessos: React.FC<ProcessosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProcessosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProcessos={ProcessosEmpty()}>
        </ProcessosWindow>
    )
};

export default ProcessosWindow;