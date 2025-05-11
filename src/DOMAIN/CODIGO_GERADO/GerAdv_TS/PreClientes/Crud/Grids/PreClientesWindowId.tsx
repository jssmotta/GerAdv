// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IPreClientes } from "../../Interfaces/interface.PreClientes";
import { PreClientesService } from "../../Services/PreClientes.service";
import { PreClientesApi } from "../../Apis/ApiPreClientes";
import PreClientesWindow from "./PreClientesWindow";

interface PreClientesWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const PreClientesWindowId: React.FC<PreClientesWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const preclientesService = useMemo(() => {
        return new PreClientesService(
            new PreClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IPreClientes | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await preclientesService.fetchPreClientesById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <PreClientesWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedPreClientes={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default PreClientesWindowId;