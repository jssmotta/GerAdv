﻿import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import StatusInstanciaInc from "../Inc/StatusInstancia";
import { IStatusInstancia } from "../../Interfaces/interface.StatusInstancia";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { StatusInstanciaEmpty } from "@/app/GerAdv_TS/Models/StatusInstancia";
import { useWindow } from "@/app/hooks/useWindows";

interface StatusInstanciaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedStatusInstancia?: IStatusInstancia;
    onSuccess: () => void;
    onError: () => void;
}

const StatusInstanciaWindow: React.FC<StatusInstanciaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedStatusInstancia,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/statusinstancia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedStatusInstancia?.id}`);
        }

    }, [isMobile, router, selectedStatusInstancia]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedStatusInstancia?.id ?? 0).toString()}
                >
                    <StatusInstanciaInc
                        id={selectedStatusInstancia?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowStatusInstancia: React.FC<StatusInstanciaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <StatusInstanciaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedStatusInstancia={StatusInstanciaEmpty()}>
        </StatusInstanciaWindow>
    )
};

export default StatusInstanciaWindow;