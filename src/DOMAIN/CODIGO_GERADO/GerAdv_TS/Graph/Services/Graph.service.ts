"use client";
import { GraphApi } from "../Apis/ApiGraph";
import { IGraph } from "../Interfaces/interface.Graph";
import { FilterGraph } from "../Filters/Graph";

  export interface IGraphService {
    fetchGraphById: (id: number) => Promise<IGraph>;
    saveGraph: (graph: IGraph) => Promise<IGraph>;
    
  }
  
  export class GraphService implements IGraphService {
    constructor(private api: GraphApi) {}
  
    async fetchGraphById(id: number): Promise<IGraph> {
      const response = await this.api.getById(id);
      return response.data;
    }
  
    async saveGraph(graph: IGraph): Promise<IGraph> {
      const response = await this.api.addAndUpdate(graph as IGraph);
      return response.data;
    }
 
   async getAll(filtro?: FilterGraph): Promise<IGraph[]> {
    try {
      const response = await this.api.filter(filtro ?? {});
      return response.data;
    } catch (error) {
      console.error('Error fetching graph:', error);
      return [];
    }
  }

  }