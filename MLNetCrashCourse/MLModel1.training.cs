﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML.Transforms;
using Microsoft.ML;

namespace MLNetCrashCourse
{
    public partial class MLModel1
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(@"ocean_proximity", @"ocean_proximity", outputKind: OneHotEncodingEstimator.OutputKind.Indicator)      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"longitude", @"longitude"),new InputOutputColumnPair(@"latitude", @"latitude"),new InputOutputColumnPair(@"housing_median_age", @"housing_median_age"),new InputOutputColumnPair(@"total_rooms", @"total_rooms"),new InputOutputColumnPair(@"total_bedrooms", @"total_bedrooms"),new InputOutputColumnPair(@"population", @"population"),new InputOutputColumnPair(@"households", @"households"),new InputOutputColumnPair(@"median_income", @"median_income")}))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"ocean_proximity",@"longitude",@"latitude",@"housing_median_age",@"total_rooms",@"total_bedrooms",@"population",@"households",@"median_income"}))      
                                    .Append(mlContext.Regression.Trainers.LightGbm(new LightGbmRegressionTrainer.Options(){NumberOfLeaves=4,NumberOfIterations=2838,MinimumExampleCountPerLeaf=227,LearningRate=0.999999776672986,LabelColumnName=@"median_house_value",FeatureColumnName=@"Features",ExampleWeightColumnName=null,Booster=new GradientBooster.Options(){SubsampleFraction=0.999999776672986,FeatureFraction=0.295412256866274,L1Regularization=7.41645859292214E-10,L2Regularization=0.999999776672986},MaximumBinCountPerFeature=1022}));

            return pipeline;
        }
    }
}