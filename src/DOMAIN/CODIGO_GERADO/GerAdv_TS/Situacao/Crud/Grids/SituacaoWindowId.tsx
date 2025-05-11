// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ISituacao } from "../../Interfaces/interface.Situacao";
import { SituacaoService } from "../../Services/Situacao.service";
import { SituacaoApi } from "../../Apis/ApiSituacao";
import SituacaoWindow from "./SituacaoWindow";

interface SituacaoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const SituacaoWindowId: React.FC<SituacaoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const situacaoService = useMemo(() => {
        return new SituacaoService(
            new SituacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ISituacao | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await situacaoService.fetchSituacaoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <SituacaoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedSituacao={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default SituacaoWindowId;