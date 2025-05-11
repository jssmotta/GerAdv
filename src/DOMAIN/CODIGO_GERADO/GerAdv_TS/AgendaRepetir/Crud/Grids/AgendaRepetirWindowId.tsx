// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IAgendaRepetir } from "../../Interfaces/interface.AgendaRepetir";
import { AgendaRepetirService } from "../../Services/AgendaRepetir.service";
import { AgendaRepetirApi } from "../../Apis/ApiAgendaRepetir";
import AgendaRepetirWindow from "./AgendaRepetirWindow";

interface AgendaRepetirWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaRepetirWindowId: React.FC<AgendaRepetirWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const agendarepetirService = useMemo(() => {
        return new AgendaRepetirService(
            new AgendaRepetirApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IAgendaRepetir | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await agendarepetirService.fetchAgendaRepetirById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <AgendaRepetirWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedAgendaRepetir={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default AgendaRepetirWindowId;