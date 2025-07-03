import React from 'react';
import { render } from '@testing-library/react';
import PrepostosIncContainer from '@/app/GerAdv_TS/Prepostos/Components/PrepostosIncContainer';
// PrepostosIncContainer.test.tsx
// Mock do PrepostosInc
jest.mock('@/app/GerAdv_TS/Prepostos/Crud/Inc/Prepostos', () => (props: any) => (
<div data-testid='prepostos-inc-mock' {...props} />
));
describe('PrepostosIncContainer', () => {
  it('deve renderizar PrepostosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <PrepostosIncContainer id={id} navigator={mockNavigator} />
  );
  const prepostosInc = getByTestId('prepostos-inc-mock');
  expect(prepostosInc).toBeInTheDocument();
  expect(prepostosInc.getAttribute('id')).toBe(id.toString());

});
});