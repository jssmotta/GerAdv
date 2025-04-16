import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ProcessOutputEngineInc from "../Inc/ProcessOutputEngine";
import { IProcessOutputEngine } from "../../Interfaces/interface.ProcessOutputEngine";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProcessOutputEngineEmpty } from "@/app/GerAdv_TS/Models/ProcessOutputEngine";
import { useWindow } from "@/app/hooks/useWindows";

interface ProcessOutputEngineWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProcessOutputEngine?: IProcessOutputEngine;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessOutputEngineWindow: React.FC<ProcessOutputEngineWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProcessOutputEngine,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/processoutputengine/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProcessOutputEngine?.id}`);
        }

    }, [isMobile, router, selectedProcessOutputEngine]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={563}
                    newWidth={1440}
                    id={(selectedProcessOutputEngine?.id ?? 0).toString()}
                >
                    <ProcessOutputEngineInc
                        id={selectedProcessOutputEngine?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProcessOutputEngine: React.FC<ProcessOutputEngineWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProcessOutputEngineWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProcessOutputEngine={ProcessOutputEngineEmpty()}>
        </ProcessOutputEngineWindow>
    )
};

export default ProcessOutputEngineWindow;