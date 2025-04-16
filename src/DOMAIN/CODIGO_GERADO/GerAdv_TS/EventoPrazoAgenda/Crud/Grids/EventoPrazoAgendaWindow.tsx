import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import EventoPrazoAgendaInc from "../Inc/EventoPrazoAgenda";
import { IEventoPrazoAgenda } from "../../Interfaces/interface.EventoPrazoAgenda";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { EventoPrazoAgendaEmpty } from "@/app/GerAdv_TS/Models/EventoPrazoAgenda";
import { useWindow } from "@/app/hooks/useWindows";

interface EventoPrazoAgendaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedEventoPrazoAgenda?: IEventoPrazoAgenda;
    onSuccess: () => void;
    onError: () => void;
}

const EventoPrazoAgendaWindow: React.FC<EventoPrazoAgendaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedEventoPrazoAgenda,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/eventoprazoagenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedEventoPrazoAgenda?.id}`);
        }

    }, [isMobile, router, selectedEventoPrazoAgenda]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedEventoPrazoAgenda?.id ?? 0).toString()}
                >
                    <EventoPrazoAgendaInc
                        id={selectedEventoPrazoAgenda?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowEventoPrazoAgenda: React.FC<EventoPrazoAgendaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <EventoPrazoAgendaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedEventoPrazoAgenda={EventoPrazoAgendaEmpty()}>
        </EventoPrazoAgendaWindow>
    )
};

export default EventoPrazoAgendaWindow;