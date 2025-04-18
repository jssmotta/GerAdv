﻿import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import AgendaRecordsInc from "../Inc/AgendaRecords";
import { IAgendaRecords } from "../../Interfaces/interface.AgendaRecords";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AgendaRecordsEmpty } from "@/app/GerAdv_TS/Models/AgendaRecords";
import { useWindow } from "@/app/hooks/useWindows";

interface AgendaRecordsWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAgendaRecords?: IAgendaRecords;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaRecordsWindow: React.FC<AgendaRecordsWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAgendaRecords,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/agendarecords/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAgendaRecords?.id}`);
        }

    }, [isMobile, router, selectedAgendaRecords]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={653}
                    newWidth={1440}
                    id={(selectedAgendaRecords?.id ?? 0).toString()}
                >
                    <AgendaRecordsInc
                        id={selectedAgendaRecords?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAgendaRecords: React.FC<AgendaRecordsWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AgendaRecordsWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAgendaRecords={AgendaRecordsEmpty()}>
        </AgendaRecordsWindow>
    )
};

export default AgendaRecordsWindow;