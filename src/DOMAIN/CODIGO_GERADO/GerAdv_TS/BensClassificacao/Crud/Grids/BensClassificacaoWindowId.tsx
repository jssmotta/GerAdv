// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IBensClassificacao } from "../../Interfaces/interface.BensClassificacao";
import { BensClassificacaoService } from "../../Services/BensClassificacao.service";
import { BensClassificacaoApi } from "../../Apis/ApiBensClassificacao";
import BensClassificacaoWindow from "./BensClassificacaoWindow";

interface BensClassificacaoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const BensClassificacaoWindowId: React.FC<BensClassificacaoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const bensclassificacaoService = useMemo(() => {
        return new BensClassificacaoService(
            new BensClassificacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IBensClassificacao | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await bensclassificacaoService.fetchBensClassificacaoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <BensClassificacaoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedBensClassificacao={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default BensClassificacaoWindowId;