// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ITipoContatoCRM } from "../../Interfaces/interface.TipoContatoCRM";
import { TipoContatoCRMService } from "../../Services/TipoContatoCRM.service";
import { TipoContatoCRMApi } from "../../Apis/ApiTipoContatoCRM";
import TipoContatoCRMWindow from "./TipoContatoCRMWindow";

interface TipoContatoCRMWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const TipoContatoCRMWindowId: React.FC<TipoContatoCRMWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const tipocontatocrmService = useMemo(() => {
        return new TipoContatoCRMService(
            new TipoContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ITipoContatoCRM | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await tipocontatocrmService.fetchTipoContatoCRMById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <TipoContatoCRMWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedTipoContatoCRM={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default TipoContatoCRMWindowId;