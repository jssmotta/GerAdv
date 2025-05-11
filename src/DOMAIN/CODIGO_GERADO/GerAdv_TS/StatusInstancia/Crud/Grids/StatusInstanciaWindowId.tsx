// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IStatusInstancia } from "../../Interfaces/interface.StatusInstancia";
import { StatusInstanciaService } from "../../Services/StatusInstancia.service";
import { StatusInstanciaApi } from "../../Apis/ApiStatusInstancia";
import StatusInstanciaWindow from "./StatusInstanciaWindow";

interface StatusInstanciaWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const StatusInstanciaWindowId: React.FC<StatusInstanciaWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const statusinstanciaService = useMemo(() => {
        return new StatusInstanciaService(
            new StatusInstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IStatusInstancia | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await statusinstanciaService.fetchStatusInstanciaById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <StatusInstanciaWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedStatusInstancia={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default StatusInstanciaWindowId;