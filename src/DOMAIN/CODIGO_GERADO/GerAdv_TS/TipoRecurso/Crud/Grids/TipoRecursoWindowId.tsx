// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ITipoRecurso } from "../../Interfaces/interface.TipoRecurso";
import { TipoRecursoService } from "../../Services/TipoRecurso.service";
import { TipoRecursoApi } from "../../Apis/ApiTipoRecurso";
import TipoRecursoWindow from "./TipoRecursoWindow";

interface TipoRecursoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const TipoRecursoWindowId: React.FC<TipoRecursoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const tiporecursoService = useMemo(() => {
        return new TipoRecursoService(
            new TipoRecursoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ITipoRecurso | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await tiporecursoService.fetchTipoRecursoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <TipoRecursoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedTipoRecurso={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default TipoRecursoWindowId;