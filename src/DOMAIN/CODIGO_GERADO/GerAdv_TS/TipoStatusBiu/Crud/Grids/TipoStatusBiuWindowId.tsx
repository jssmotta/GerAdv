// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ITipoStatusBiu } from "../../Interfaces/interface.TipoStatusBiu";
import { TipoStatusBiuService } from "../../Services/TipoStatusBiu.service";
import { TipoStatusBiuApi } from "../../Apis/ApiTipoStatusBiu";
import TipoStatusBiuWindow from "./TipoStatusBiuWindow";

interface TipoStatusBiuWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const TipoStatusBiuWindowId: React.FC<TipoStatusBiuWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const tipostatusbiuService = useMemo(() => {
        return new TipoStatusBiuService(
            new TipoStatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ITipoStatusBiu | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await tipostatusbiuService.fetchTipoStatusBiuById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <TipoStatusBiuWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedTipoStatusBiu={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default TipoStatusBiuWindowId;