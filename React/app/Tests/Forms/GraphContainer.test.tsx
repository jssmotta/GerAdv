import React from 'react';
import { render } from '@testing-library/react';
import GraphIncContainer from '@/app/GerAdv_TS/Graph/Components/GraphIncContainer';
// GraphIncContainer.test.tsx
// Mock do GraphInc
jest.mock('@/app/GerAdv_TS/Graph/Crud/Inc/Graph', () => (props: any) => (
<div data-testid='graph-inc-mock' {...props} />
));
describe('GraphIncContainer', () => {
  it('deve renderizar GraphInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <GraphIncContainer id={id} navigator={mockNavigator} />
  );
  const graphInc = getByTestId('graph-inc-mock');
  expect(graphInc).toBeInTheDocument();
  expect(graphInc.getAttribute('id')).toBe(id.toString());

});
});