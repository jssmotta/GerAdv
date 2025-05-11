// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IStatusTarefas } from "../../Interfaces/interface.StatusTarefas";
import { StatusTarefasService } from "../../Services/StatusTarefas.service";
import { StatusTarefasApi } from "../../Apis/ApiStatusTarefas";
import StatusTarefasWindow from "./StatusTarefasWindow";

interface StatusTarefasWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const StatusTarefasWindowId: React.FC<StatusTarefasWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const statustarefasService = useMemo(() => {
        return new StatusTarefasService(
            new StatusTarefasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IStatusTarefas | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await statustarefasService.fetchStatusTarefasById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <StatusTarefasWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedStatusTarefas={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default StatusTarefasWindowId;