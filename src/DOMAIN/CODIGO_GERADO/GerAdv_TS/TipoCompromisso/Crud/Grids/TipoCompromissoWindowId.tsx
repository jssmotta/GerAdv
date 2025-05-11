// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ITipoCompromisso } from "../../Interfaces/interface.TipoCompromisso";
import { TipoCompromissoService } from "../../Services/TipoCompromisso.service";
import { TipoCompromissoApi } from "../../Apis/ApiTipoCompromisso";
import TipoCompromissoWindow from "./TipoCompromissoWindow";

interface TipoCompromissoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const TipoCompromissoWindowId: React.FC<TipoCompromissoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const tipocompromissoService = useMemo(() => {
        return new TipoCompromissoService(
            new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ITipoCompromisso | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await tipocompromissoService.fetchTipoCompromissoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <TipoCompromissoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedTipoCompromisso={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default TipoCompromissoWindowId;