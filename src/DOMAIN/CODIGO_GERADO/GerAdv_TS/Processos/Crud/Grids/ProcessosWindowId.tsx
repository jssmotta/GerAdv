// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IProcessos } from "../../Interfaces/interface.Processos";
import { ProcessosService } from "../../Services/Processos.service";
import { ProcessosApi } from "../../Apis/ApiProcessos";
import ProcessosWindow from "./ProcessosWindow";

interface ProcessosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessosWindowId: React.FC<ProcessosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const processosService = useMemo(() => {
        return new ProcessosService(
            new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IProcessos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await processosService.fetchProcessosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ProcessosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedProcessos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ProcessosWindowId;