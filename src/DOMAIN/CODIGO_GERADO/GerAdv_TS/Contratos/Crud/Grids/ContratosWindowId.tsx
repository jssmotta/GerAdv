// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IContratos } from "../../Interfaces/interface.Contratos";
import { ContratosService } from "../../Services/Contratos.service";
import { ContratosApi } from "../../Apis/ApiContratos";
import ContratosWindow from "./ContratosWindow";

interface ContratosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ContratosWindowId: React.FC<ContratosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const contratosService = useMemo(() => {
        return new ContratosService(
            new ContratosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IContratos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await contratosService.fetchContratosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ContratosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedContratos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ContratosWindowId;