import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ProcessosParadosInc from "../Inc/ProcessosParados";
import { IProcessosParados } from "../../Interfaces/interface.ProcessosParados";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProcessosParadosEmpty } from "@/app/GerAdv_TS/Models/ProcessosParados";
import { useWindow } from "@/app/hooks/useWindows";

interface ProcessosParadosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProcessosParados?: IProcessosParados;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessosParadosWindow: React.FC<ProcessosParadosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProcessosParados,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/processosparados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProcessosParados?.id}`);
        }

    }, [isMobile, router, selectedProcessosParados]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={725}
                    newWidth={720}
                    id={(selectedProcessosParados?.id ?? 0).toString()}
                >
                    <ProcessosParadosInc
                        id={selectedProcessosParados?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProcessosParados: React.FC<ProcessosParadosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProcessosParadosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProcessosParados={ProcessosParadosEmpty()}>
        </ProcessosParadosWindow>
    )
};

export default ProcessosParadosWindow;