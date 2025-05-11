// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IEventoPrazoAgenda } from "../../Interfaces/interface.EventoPrazoAgenda";
import { EventoPrazoAgendaService } from "../../Services/EventoPrazoAgenda.service";
import { EventoPrazoAgendaApi } from "../../Apis/ApiEventoPrazoAgenda";
import EventoPrazoAgendaWindow from "./EventoPrazoAgendaWindow";

interface EventoPrazoAgendaWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const EventoPrazoAgendaWindowId: React.FC<EventoPrazoAgendaWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const eventoprazoagendaService = useMemo(() => {
        return new EventoPrazoAgendaService(
            new EventoPrazoAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IEventoPrazoAgenda | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await eventoprazoagendaService.fetchEventoPrazoAgendaById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <EventoPrazoAgendaWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedEventoPrazoAgenda={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default EventoPrazoAgendaWindowId;