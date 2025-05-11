// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IAgenda } from "../../Interfaces/interface.Agenda";
import { AgendaService } from "../../Services/Agenda.service";
import { AgendaApi } from "../../Apis/ApiAgenda";
import AgendaWindow from "./AgendaWindow";

interface AgendaWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaWindowId: React.FC<AgendaWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const agendaService = useMemo(() => {
        return new AgendaService(
            new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IAgenda | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await agendaService.fetchAgendaById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <AgendaWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedAgenda={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default AgendaWindowId;