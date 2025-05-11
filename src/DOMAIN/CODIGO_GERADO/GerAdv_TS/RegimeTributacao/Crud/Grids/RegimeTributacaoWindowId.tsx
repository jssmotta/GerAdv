// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IRegimeTributacao } from "../../Interfaces/interface.RegimeTributacao";
import { RegimeTributacaoService } from "../../Services/RegimeTributacao.service";
import { RegimeTributacaoApi } from "../../Apis/ApiRegimeTributacao";
import RegimeTributacaoWindow from "./RegimeTributacaoWindow";

interface RegimeTributacaoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const RegimeTributacaoWindowId: React.FC<RegimeTributacaoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const regimetributacaoService = useMemo(() => {
        return new RegimeTributacaoService(
            new RegimeTributacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IRegimeTributacao | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await regimetributacaoService.fetchRegimeTributacaoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <RegimeTributacaoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedRegimeTributacao={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default RegimeTributacaoWindowId;