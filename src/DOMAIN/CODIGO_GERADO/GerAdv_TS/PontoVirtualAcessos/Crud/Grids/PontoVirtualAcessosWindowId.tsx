// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IPontoVirtualAcessos } from "../../Interfaces/interface.PontoVirtualAcessos";
import { PontoVirtualAcessosService } from "../../Services/PontoVirtualAcessos.service";
import { PontoVirtualAcessosApi } from "../../Apis/ApiPontoVirtualAcessos";
import PontoVirtualAcessosWindow from "./PontoVirtualAcessosWindow";

interface PontoVirtualAcessosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const PontoVirtualAcessosWindowId: React.FC<PontoVirtualAcessosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const pontovirtualacessosService = useMemo(() => {
        return new PontoVirtualAcessosService(
            new PontoVirtualAcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IPontoVirtualAcessos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await pontovirtualacessosService.fetchPontoVirtualAcessosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <PontoVirtualAcessosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedPontoVirtualAcessos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default PontoVirtualAcessosWindowId;