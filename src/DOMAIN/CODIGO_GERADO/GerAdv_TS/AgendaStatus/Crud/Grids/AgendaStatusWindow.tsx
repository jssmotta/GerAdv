import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import AgendaStatusInc from "../Inc/AgendaStatus";
import { IAgendaStatus } from "../../Interfaces/interface.AgendaStatus";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AgendaStatusEmpty } from "@/app/GerAdv_TS/Models/AgendaStatus";
import { useWindow } from "@/app/hooks/useWindows";

interface AgendaStatusWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAgendaStatus?: IAgendaStatus;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaStatusWindow: React.FC<AgendaStatusWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAgendaStatus,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/agendastatus/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAgendaStatus?.id}`);
        }

    }, [isMobile, router, selectedAgendaStatus]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAgendaStatus?.id ?? 0).toString()}
                >
                    <AgendaStatusInc
                        id={selectedAgendaStatus?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAgendaStatus: React.FC<AgendaStatusWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AgendaStatusWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAgendaStatus={AgendaStatusEmpty()}>
        </AgendaStatusWindow>
    )
};

export default AgendaStatusWindow;