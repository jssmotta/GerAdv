// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IApenso2 } from "../../Interfaces/interface.Apenso2";
import { Apenso2Service } from "../../Services/Apenso2.service";
import { Apenso2Api } from "../../Apis/ApiApenso2";
import Apenso2Window from "./Apenso2Window";

interface Apenso2WindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const Apenso2WindowId: React.FC<Apenso2WindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const apenso2Service = useMemo(() => {
        return new Apenso2Service(
            new Apenso2Api(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IApenso2 | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await apenso2Service.fetchApenso2ById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <Apenso2Window 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedApenso2={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default Apenso2WindowId;