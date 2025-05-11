// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IAgendaRecords } from "../../Interfaces/interface.AgendaRecords";
import { AgendaRecordsService } from "../../Services/AgendaRecords.service";
import { AgendaRecordsApi } from "../../Apis/ApiAgendaRecords";
import AgendaRecordsWindow from "./AgendaRecordsWindow";

interface AgendaRecordsWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaRecordsWindowId: React.FC<AgendaRecordsWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const agendarecordsService = useMemo(() => {
        return new AgendaRecordsService(
            new AgendaRecordsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IAgendaRecords | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await agendarecordsService.fetchAgendaRecordsById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <AgendaRecordsWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedAgendaRecords={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default AgendaRecordsWindowId;