import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AgendaQuemInc from "../Inc/AgendaQuem";
import { IAgendaQuem } from "../../Interfaces/interface.AgendaQuem";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AgendaQuemEmpty } from "@/app/GerAdv_TS/Models/AgendaQuem";
import { useWindow } from "@/app/hooks/useWindows";

interface AgendaQuemWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAgendaQuem?: IAgendaQuem;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaQuemWindow: React.FC<AgendaQuemWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAgendaQuem,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/agendaquem/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAgendaQuem?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAgendaQuem]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAgendaQuem?.id ?? 0).toString()}
                >
                    <AgendaQuemInc
                        id={selectedAgendaQuem?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAgendaQuem: React.FC<AgendaQuemWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AgendaQuemWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAgendaQuem={AgendaQuemEmpty()}>
        </AgendaQuemWindow>
    )
};

export default AgendaQuemWindow;