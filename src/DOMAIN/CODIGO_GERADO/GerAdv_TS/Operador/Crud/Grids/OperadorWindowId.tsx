// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IOperador } from "../../Interfaces/interface.Operador";
import { OperadorService } from "../../Services/Operador.service";
import { OperadorApi } from "../../Apis/ApiOperador";
import OperadorWindow from "./OperadorWindow";

interface OperadorWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const OperadorWindowId: React.FC<OperadorWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const operadorService = useMemo(() => {
        return new OperadorService(
            new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IOperador | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await operadorService.fetchOperadorById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <OperadorWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedOperador={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default OperadorWindowId;