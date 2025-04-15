import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import AgendaRepetirInc from "../Inc/AgendaRepetir";
import { IAgendaRepetir } from "../../Interfaces/interface.AgendaRepetir";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AgendaRepetirEmpty } from "@/app/GerAdv_TS/Models/AgendaRepetir";
import { useWindow } from "@/app/hooks/useWindows";

interface AgendaRepetirWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAgendaRepetir?: IAgendaRepetir;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaRepetirWindow: React.FC<AgendaRepetirWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAgendaRepetir,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/agendarepetir/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAgendaRepetir?.id}`);
        }

    }, [isMobile, router, selectedAgendaRepetir]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={818}
                    newWidth={1440}
                    id={(selectedAgendaRepetir?.id ?? 0).toString()}
                >
                    <AgendaRepetirInc
                        id={selectedAgendaRepetir?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAgendaRepetir: React.FC<AgendaRepetirWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AgendaRepetirWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAgendaRepetir={AgendaRepetirEmpty()}>
        </AgendaRepetirWindow>
    )
};

export default AgendaRepetirWindow;