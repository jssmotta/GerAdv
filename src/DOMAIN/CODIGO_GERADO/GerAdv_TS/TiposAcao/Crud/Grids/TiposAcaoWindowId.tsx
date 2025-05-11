// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ITiposAcao } from "../../Interfaces/interface.TiposAcao";
import { TiposAcaoService } from "../../Services/TiposAcao.service";
import { TiposAcaoApi } from "../../Apis/ApiTiposAcao";
import TiposAcaoWindow from "./TiposAcaoWindow";

interface TiposAcaoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const TiposAcaoWindowId: React.FC<TiposAcaoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const tiposacaoService = useMemo(() => {
        return new TiposAcaoService(
            new TiposAcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ITiposAcao | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await tiposacaoService.fetchTiposAcaoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <TiposAcaoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedTiposAcao={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default TiposAcaoWindowId;