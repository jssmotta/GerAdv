// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IAgendaStatus } from "../../Interfaces/interface.AgendaStatus";
import { AgendaStatusService } from "../../Services/AgendaStatus.service";
import { AgendaStatusApi } from "../../Apis/ApiAgendaStatus";
import AgendaStatusWindow from "./AgendaStatusWindow";

interface AgendaStatusWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaStatusWindowId: React.FC<AgendaStatusWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const agendastatusService = useMemo(() => {
        return new AgendaStatusService(
            new AgendaStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IAgendaStatus | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await agendastatusService.fetchAgendaStatusById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <AgendaStatusWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedAgendaStatus={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default AgendaStatusWindowId;