"use client";
import { useState } from 'react';
import { IGraph } from '../Interfaces/interface.Graph';
import { IGraphService } from '../Services/Graph.service';

export const useGraphForm = (
  initialGraph: IGraph,
  dataService: IGraphService
) => {
  const [data, setData] = useState<IGraph>(initialGraph);

  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setData((prev: any) => ({
      ...prev,
      [name]: value,
    }));
  };

  const loadGraph = async (id: number) => {
    if (id) {
      const dados = await dataService.fetchGraphById(id);
      setData(dados);
    }
  };

  return {
    data,
    handleChange,
    loadGraph,
  };
};
