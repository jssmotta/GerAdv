// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IOperadorGrupo } from "../../Interfaces/interface.OperadorGrupo";
import { OperadorGrupoService } from "../../Services/OperadorGrupo.service";
import { OperadorGrupoApi } from "../../Apis/ApiOperadorGrupo";
import OperadorGrupoWindow from "./OperadorGrupoWindow";

interface OperadorGrupoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const OperadorGrupoWindowId: React.FC<OperadorGrupoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const operadorgrupoService = useMemo(() => {
        return new OperadorGrupoService(
            new OperadorGrupoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IOperadorGrupo | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await operadorgrupoService.fetchOperadorGrupoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <OperadorGrupoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedOperadorGrupo={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default OperadorGrupoWindowId;