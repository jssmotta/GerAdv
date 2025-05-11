// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IStatusAndamento } from "../../Interfaces/interface.StatusAndamento";
import { StatusAndamentoService } from "../../Services/StatusAndamento.service";
import { StatusAndamentoApi } from "../../Apis/ApiStatusAndamento";
import StatusAndamentoWindow from "./StatusAndamentoWindow";

interface StatusAndamentoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const StatusAndamentoWindowId: React.FC<StatusAndamentoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const statusandamentoService = useMemo(() => {
        return new StatusAndamentoService(
            new StatusAndamentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IStatusAndamento | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await statusandamentoService.fetchStatusAndamentoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <StatusAndamentoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedStatusAndamento={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default StatusAndamentoWindowId;