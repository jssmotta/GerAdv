// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IDadosProcuracao } from "../../Interfaces/interface.DadosProcuracao";
import { DadosProcuracaoService } from "../../Services/DadosProcuracao.service";
import { DadosProcuracaoApi } from "../../Apis/ApiDadosProcuracao";
import DadosProcuracaoWindow from "./DadosProcuracaoWindow";

interface DadosProcuracaoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const DadosProcuracaoWindowId: React.FC<DadosProcuracaoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const dadosprocuracaoService = useMemo(() => {
        return new DadosProcuracaoService(
            new DadosProcuracaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IDadosProcuracao | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await dadosprocuracaoService.fetchDadosProcuracaoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <DadosProcuracaoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedDadosProcuracao={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default DadosProcuracaoWindowId;