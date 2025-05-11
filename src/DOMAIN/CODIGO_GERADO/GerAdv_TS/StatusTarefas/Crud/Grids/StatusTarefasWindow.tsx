import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import StatusTarefasInc from "../Inc/StatusTarefas";
import { IStatusTarefas } from "../../Interfaces/interface.StatusTarefas";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { StatusTarefasEmpty } from "@/app/GerAdv_TS/Models/StatusTarefas";
import { useWindow } from "@/app/hooks/useWindows";

interface StatusTarefasWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedStatusTarefas?: IStatusTarefas;
    onSuccess: () => void;
    onError: () => void;
}

const StatusTarefasWindow: React.FC<StatusTarefasWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedStatusTarefas,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/statustarefas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedStatusTarefas?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedStatusTarefas]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedStatusTarefas?.id ?? 0).toString()}
                >
                    <StatusTarefasInc
                        id={selectedStatusTarefas?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowStatusTarefas: React.FC<StatusTarefasWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <StatusTarefasWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedStatusTarefas={StatusTarefasEmpty()}>
        </StatusTarefasWindow>
    )
};

export default StatusTarefasWindow;