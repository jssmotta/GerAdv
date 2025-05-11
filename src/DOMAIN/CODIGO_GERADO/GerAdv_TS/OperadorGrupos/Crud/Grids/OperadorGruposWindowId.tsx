// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IOperadorGrupos } from "../../Interfaces/interface.OperadorGrupos";
import { OperadorGruposService } from "../../Services/OperadorGrupos.service";
import { OperadorGruposApi } from "../../Apis/ApiOperadorGrupos";
import OperadorGruposWindow from "./OperadorGruposWindow";

interface OperadorGruposWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const OperadorGruposWindowId: React.FC<OperadorGruposWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const operadorgruposService = useMemo(() => {
        return new OperadorGruposService(
            new OperadorGruposApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IOperadorGrupos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await operadorgruposService.fetchOperadorGruposById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <OperadorGruposWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedOperadorGrupos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default OperadorGruposWindowId;