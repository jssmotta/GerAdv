// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IAgendaRepetirDias } from "../../Interfaces/interface.AgendaRepetirDias";
import { AgendaRepetirDiasService } from "../../Services/AgendaRepetirDias.service";
import { AgendaRepetirDiasApi } from "../../Apis/ApiAgendaRepetirDias";
import AgendaRepetirDiasWindow from "./AgendaRepetirDiasWindow";

interface AgendaRepetirDiasWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaRepetirDiasWindowId: React.FC<AgendaRepetirDiasWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const agendarepetirdiasService = useMemo(() => {
        return new AgendaRepetirDiasService(
            new AgendaRepetirDiasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IAgendaRepetirDias | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await agendarepetirdiasService.fetchAgendaRepetirDiasById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <AgendaRepetirDiasWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedAgendaRepetirDias={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default AgendaRepetirDiasWindowId;