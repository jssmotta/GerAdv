import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import StatusAndamentoInc from "../Inc/StatusAndamento";
import { IStatusAndamento } from "../../Interfaces/interface.StatusAndamento";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { StatusAndamentoEmpty } from "@/app/GerAdv_TS/Models/StatusAndamento";
import { useWindow } from "@/app/hooks/useWindows";

interface StatusAndamentoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedStatusAndamento?: IStatusAndamento;
    onSuccess: () => void;
    onError: () => void;
}

const StatusAndamentoWindow: React.FC<StatusAndamentoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedStatusAndamento,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/statusandamento/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedStatusAndamento?.id}`);
        }

    }, [isMobile, router, selectedStatusAndamento]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedStatusAndamento?.id ?? 0).toString()}
                >
                    <StatusAndamentoInc
                        id={selectedStatusAndamento?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowStatusAndamento: React.FC<StatusAndamentoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <StatusAndamentoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedStatusAndamento={StatusAndamentoEmpty()}>
        </StatusAndamentoWindow>
    )
};

export default StatusAndamentoWindow;